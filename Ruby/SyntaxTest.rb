#/usr/bin/ruby

=begin
NAME
  SyntaxTest

SYNOPSIS
  ./SyntaxTest.rb

DESCRIPTION
  Tests the AltCoinSamples Ruby files for syntax errors.

USAGE
  ./SyntaxTest.rb
    Runs tests for each Ruby file
=end

require "test/unit"

class SyntaxClass < Test::Unit::TestCase
  def syntax_ok
    return "Syntax OK"
  end

  def check_syntax(file)
    return `ruby -c #{file}`.chomp
  end

  def test_hashing
    assert_equal syntax_ok, check_syntax("hashing.rb")
  end

  def test_mining
    assert_equal syntax_ok, check_syntax("mining.rb")
  end
end
