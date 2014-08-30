require "Slop"
require "Digest"

$hasher = Digest::MD5.new

def solve_block_zero(input, target)
  hash = ""
  nonce = 0
  while (hash.start_with?(target) == false) do
    input_nonce = input + nonce.to_s
    hash = $hasher.reset.update(input_nonce).to_s
    nonce = nonce + 1
  end

  return [hash, nonce + 1]
end

def solve_block_limit(input, target)
  solved = false
  nonce = 0
  while (solved == false) do
    input_nonce = input + nonce.to_s
    hash = $hasher.reset.update(input_nonce).to_s
    nonce = nonce + 1
    if (hash.hex < target) then
      return [hash, nonce]
    end
  end
end

./mining.rb input -b 100 -m zero|limit|text|auto -t target -a

opts = Slop.parse! do
  on :b, :blocks=, "Blocks", as: Integer
  on :m, :mode=, "Mode", as: String
  on :t, :target=, "Target", as: String
end

blocks = (opts.blocks?) ? opts[:blocks] : 1
mode = (opts.mode?) ? opts[:mode] : "auto"
target = (opts.target?) ? opts[:target] : ""

if (mode != "zero" && mode != "limit" && mode != "text" && mode != "auto") then
  puts "Unrecognised mode parameter: #{mode}"
  exit(1)
end

input = ARGV[0]
target = ARGV[1].hex
blocks = ARGV[2].to_i

values = [input, 0]
(1..blocks).each do |b|
  #values = solve_block(values[0], target)
  values = solve_block_limit(values[0], target)
  puts "Block #{b}:"
  puts "  Hash  -> #{values[0]}"
  puts "  Count -> #{values[1]}"
end
