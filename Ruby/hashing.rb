#!/usr/bin/ruby

=begin
NAME
	Hashing

SYNOPSIS
	./hashing.rb text1 [text2] [-h bits]

DESCRIPTION
	Demonstrates hashing and its uses using the SHA2 hash algorithm.

OPTIONS
	-b or --bits bits
		Available options: 256, 384, 512
		Sets the block length for the algorithm.

USAGE
	./hashing.rb text1
		Computes and prints the SHA256 hash for text1 to the console.

	./hashing.rb text1 text2
		Computes and prints the SHA256 hashes for [text1] and [text2] to
		the console.  In addition, a True/False value explcitly declaring
		the equality of the data is displayed as well as a hash comparison
		showing which characters in the hashes are identical at the same
		position.

	./hashing.rb text1 text2 -b bits
		The -b option can be used with either usage above. The same usage
		as above is carried out except the bit length specified is used
		instead.

EXAMPLE
	./hashing.rb Hello World -b 512
		This will compute the SHA512 hashes of "Hello" and "World" and
		print them to the console with data and hash comparison info.
=end

require 'Digest'
require 'slop'

text1 = ""
text2 = ""
bits = 0

def compute_hash(text, bits)
	sha = Digest::SHA2.new(bits)
	return sha.reset.update(text).to_s
end

def print_block_length(bits)
	puts "Block Length = #{bits}"
end

opts = Slop.parse! do
	on :b, :bits=, "Bits", as: Integer
end

if opts[:bits] == nil then
	bits = 256
else
	bits = opts[:bits]
end

if ARGV.length == 1 then
	text1 = ARGV[0]
	text1_hash = compute_hash(text1, bits)
	puts "\t#{text1_hash}"
	puts "\t(Algorithm: SHA#{bits})"
elsif ARGV.length == 2 then

else
	puts "Unrecognised parameters."
	puts "Usage: ./hashing.rb text1 [text2] [-b|--bits bits]"
end
