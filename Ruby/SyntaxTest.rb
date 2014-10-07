#/usr/bin/ruby

=begin
NAME
  SyntaxTest

SYNOPSIS
  rake
  ./Ruby/SyntaxTest.rb

DESCRIPTION
  Tests the AltCoinSamples Ruby files for syntax errors.

USAGE
  It is intended for this script to be run using Rake from the parent
  directory.  It can also be run directly from the parent directory.

  rake
    Uses Rake to run tests for each Ruby file.

  ./Ruby/SyntaxTest.rb
    Runs tests for each Ruby file.
=end

require "test/unit"

=begin
Test case to test all AltCoinSamples Ruby files for syntax errors.
=end
class SyntaxClass < Test::Unit::TestCase
=begin
Summary: Returns the string returned by Ruby when the syntax of a
    file is okay.

Returns: The string when a file is okay (String).
=end
  def syntax_ok
    return "Syntax OK"
  end

=begin
Summary: Checks the syntax of a specified file.
  file    String    The filename of a Ruby file to check.

Returns: The result of the file check (String).
=end
  def check_syntax(file)
    return `ruby -c #{file}`.chomp
  end

=begin
Summary: Tests the Hashing script.
=end
  def test_hashing
    assert_equal syntax_ok, check_syntax("Ruby/hashing.rb")
  end

=begin
Summary: Tests the Mining script.
=end
  def test_mining
    assert_equal syntax_ok, check_syntax("Ruby/mining.rb")
  end
end
