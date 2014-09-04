AltCoinSamples
==============

AltCoinSamples is a collection of sample programs to demonstrate some of the concepts behind cryptocurrencies.

Two implementations are available in C# and Ruby.

Programs
--------

**Hashing**: Demonstrates the concept of hashing.  It will calculate the SHA-2 hashes of two input strings and compare them for data and hash equality.

**Mining**: Simulates the mining process.  It solves a set number of blocks conforming to a set target using the MD5 hashing algorithm.

CI Build Status
---------------

All code is built on check-in to the `master` branch.

[![Build status](https://ci.appveyor.com/api/projects/status/dvmxa8hof2i629vo)](https://ci.appveyor.com/project/BHazel/altcoinsamples)
**AppVeyor** builds the C# implementation.

[![Build Status](https://travis-ci.org/BHazel/AltCoinSamples.svg?branch=master)](https://travis-ci.org/BHazel/AltCoinSamples)
**Travis-CI** builds the Ruby implementation.