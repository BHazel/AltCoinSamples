require "Slop"
require "Digest"

$hasher = Digest::MD5.new

def get_hash(input)
  return $hasher.reset.update(input).to_s
end

def solve_block(input, target, mode)
  nonce = 0
  solved = false
  loop do
    input_with_nonce = input + nonce.to_s
    hash = get_hash(input_with_nonce)
    nonce = nonce + 1

    if (mode == "zero") then
      if (hash.start_with?(target)) then
        solved = true
      end
    else
      if (hash.hex < target) then
        solved = true
      end
    end

    if (solved) then
      return [hash, nonce]
    end
  end
end

#./mining.rb input -b 100 -m zero|limit|text|auto -t target -a

opts = Slop.parse! do
  on :b, :blocks=, "Blocks", as: Integer
  on :m, :mode=, "Mode", as: String
  on :t, :target=, "Target", as: String
end

blocks = (opts.blocks?) ? opts[:blocks] : 1
mode = (opts.mode?) ? opts[:mode] : "auto"
target = (opts.target?) ? opts[:target] : ""
input = ARGV[0]

if (mode != "zero" && mode != "limit" && mode != "text" && mode != "auto") then
  puts "Unrecognised mode parameter: #{mode}"
  exit(1)
end

if (mode == "limit") then
  target = target.hex
elsif (mode == "word") then
  target = get_hash(target)
else
  target = Time.now.to_s
end

solved_block = [input, 0]
(1..blocks).each do |b|
  solved_block = solve_block(solved_block[0], target, mode)
  puts "Block #{b}:"
  puts "  Hash  -> #{solved_block[0]}"
  puts "  Count -> #{solved_block[1]}"
end
