AltCoin Samples - Hashing Ruby Script
=====================================

Script Location
---------------

If you have installed the scripts using the installer, they can be found in the
**Ruby** subfolder of the installation directory.

Required Gems
-------------

The following gem is required for the scripts to work correctly:

* Slop: command-line argument parsing

Introduction
------------

The Hashing script demonstrates hashing using the SHA-1 algorithm.  It can be
used to:

* Compute a hash for a specified word of text
* Compute hashes for 2 specified words of text and compare them for data
equality and hash similarity

By default the SHA256 algorithm is used but the number of bits can be set to
use 384 or 512 instead.

### Compute a Single Hash

To compute a single hash for a specified word, e.g. `text`, run the following
at the command-line:

	ruby hashing.rb text

This will produce the following output:

	Algorithm:
		SHA256
	"text" =>
		982d9e3eb996f559e633f4d194def3761d909f5a3b647d1a851fead67c32c9d1

To use a different block length for the hash, use the `-b` or `--bits` flag
with options of `256`, `384` or `512` for SHA256, SHA384 or SHA512
respectively.

For example the following command would compute the SHA512 hash
of `text`:

	ruby hashing.rb text -b 512

### Compute Two Hashes and Compare Results

Providing two words to the Hashing script will automatically trigger a data
equality and hash similarity comparison.  The compared values are:

* The data equality is either **true** or **false** depending on the equality
of the hashes.
* The hash similarity compares the string representation of the hashes.  If
both hashes have a same character at the same position it is shown, otherwise
an underscore is substituted.

To compute the hashes of `text1` and `text2` and perform the comparison, run:

	ruby hashing.rb text1 text2

This will produce the following output:

	Algorithm:
		SHA256
	"text1" =>
		fe8df1a5a1980493ca9406ad3bb0e41297d979d90165a181fb39a5616a1c0789
	"text2" =>
		fd848ca35a6281600b5da598c7cb4d5df561e0ee63ee7cec0e98e6049996f3ff
	Data Equality:
		false
	Hash Similarity:
		f_8___a_________________________________________________________

To use an alternative to SHA256 (384 or 512), use the `-b` or `--bits` flag:

	ruby hashing.rb text1 text2 -b 512