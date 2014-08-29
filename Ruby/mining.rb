require "Digest"

$hasher = Digest::MD5.new

def solve_block(input, target)
  hash = ""
  nonce = 0
  while (hash.start_with?(target) == false) do
    input_nonce = input + nonce.to_s
    hash = $hasher.reset.update(input_nonce).to_s
    nonce = nonce + 1
  end

  return [hash, nonce + 1]
end

input = ARGV[0]
target = ARGV[1]
blocks = ARGV[2].to_i

values = [input, 0]
(1..blocks).each do |b|
  values = solve_block(values[0], target)
  puts "Block #{b}:"
  puts "  Hash  -> #{values[0]}"
  puts "  Count -> #{values[1]}"
end
