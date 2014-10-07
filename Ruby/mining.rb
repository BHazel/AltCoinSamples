#!/usr/bin/ruby

=begin
NAME
  Mining

SYNOPSIS
  ./mining.rb [input] [-b blocks] [-m mode] [-t target]

DESCRIPTION
  Simulates the mining process.

OPTIONS
  -b or --blocks blocks
    Default: 1
    The number of blocks to solve.

  -m or --mode mode
    Available options: auto, limit, text, zero
    Default: auto
    Sets the mode for the target
      - auto    Set a random target based on the current date and
                time and use it as the upper limit.
      - limit   Use the specified target as the upper limit to
                which computed hashes must be lower (as used by
                cryptocurrencies).  This should be a 128-bit
                hexadecimal number.
      - text    Use the hash of the target, which can be any text
                value.
      - zero    Specified target is a string of zeros to which the
                first characters of the computed hashes are
                compared.

  -t or --target target
    Default: Randomly generated according to current date and time.
    The target to solve the blocks.
    The value of the target is dependent on the mode.

USAGE
  ./mining.rb
    Solves 1 block in auto mode using an automatically generated
    target.  The seeded input is also automatically generated.

  ./mining.rb text1
    [text1] is used as a seed input to solve 1 block with an
    automatically generated target.

  ./mining.rb text1 -m limit -t 0000ffffffffffffffffffffffffffff
    The mode is set to limit therefore the specified target is
    used to compare computed hashes against: if they are lower
    then the blocked is solved.  This will solve 1 block using
    [text1] as seed input.

  ./mining.rb text1 -m text -t target -b 100
    Solves 100 blocks using [text1] as the initial seed input;
    successive blocks use the successful hash from the previous
    block as their seed input.  The target is the hash of
    [target] as the mode is text.

  ./mining.rb text1 -m zero -t 0000 -b 100
    Solves 100 blocks with [text1] as the initial seed input and
    the target in zero mode; computed hashes must start with the
    string of zeros specified in the target.
=end

require "Slop"
require "Digest"

# The MD5 hash algorithm.
$hasher = Digest::MD5.new

=begin
Summary: Computes the hash of the specified text input.
  input   String    The input text.

Returns: The computed hash (String).
=end
def get_hash(input)
  return $hasher.reset.update(input).to_s
end

=begin
Summary: Computes a hash based on the current date and time.
Returns: The computed hash (String).
=end
def get_auto_hash
  hash = get_hash(Time.now.to_s)
  zeros = rand(5)
    (0..zeros).each do |z|
    hash[z] = "0"
  end

  return hash
end

=begin
Summary: Solves a block.
  input   String    The seed input text.
  target  Any       (Integer) The hash if not in zero
                              mode.
                    (String)  The string of zeros if
                              in zero mode.
  mode    String    The mode for the target.

Returns: The successful hash and number of attempts to
    solve the block ([String, Integer]).
=end
def solve_block(input, target, mode)
  nonce = 0
  solved = false
  hash = ""
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

# Parse command-line arguments.
opts = Slop.parse! do
  on :b, :blocks=, "Blocks", as: Integer
  on :m, :mode=, "Mode", as: String
  on :t, :target=, "Target", as: String
end

blocks = (opts.blocks?) ? opts[:blocks] : 1
mode = (opts.mode?) ? opts[:mode] : "auto"
target = (opts.target?) ? opts[:target] : ""
input = ""

if (ARGV.length == 0) then
  input = get_auto_hash
else
  input = ARGV[0]
end

# Exit if an unrecognised mode is found.
if (mode != "zero" && mode != "limit" && mode != "text" && mode != "auto") then
  puts "Unrecognised mode parameter: #{mode}"
  exit(1)
end

# Set the target according to the mode.
if (mode == "limit") then
  target = target.hex
elsif (mode == "text") then
  target = get_hash(target).hex
elsif (mode == "auto") then
  target = get_auto_hash.hex
end

# Solve the blocks.
solved_block = [input, 0]
(1..blocks).each do |b|
  solved_block = solve_block(solved_block[0], target, mode)
  puts "Block #{b}:"
  puts "  Hash  -> #{solved_block[0]}"
  puts "  Count -> #{solved_block[1]}"
end
