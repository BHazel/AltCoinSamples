AltCoinSamples
==============

AltCoinSamples is a collection of sample programs to demonstrate some of the concepts behind cryptocurrencies.

Two implementations are available:

* **C#/WPF**: A Visual Studio solution is in the AltCoinSamples directory.
* **Ruby:** Scripts are in the Ruby directory.

Both include help files in Markdown format.

Programs
--------

**Hashing**: Demonstrates the concept of hashing.  It will calculate the SHA-2 hashes of two input strings and compare them for data and hash equality.

**Mining**: Simulates the mining process.  It solves a set number of blocks conforming to a set target using the MD5 hashing algorithm.

Building & Dependencies
-----------------------

An MSBuild script is provided to automate the build process.  It has been optimised for creating the installer but can be used for any component
including (MSBuild target shown in brackets):

* Building the C#/WPF apps _(WpfApps)_.
* Checking the Ruby scripts for syntax errors _(RubyScripts)_.  **Requires Ruby and Rake.**
* Creating the HTML help files from Markdown _(HelpFiles)_.  **Requires Node.js and NPM.**
* Building the installer _(Installer)_.  **Requires Inno Setup.**

To run the whole build process run the following at a Visual Studio command prompt:

    msbuild build.proj /t:All

To clean the build files, replace `/t:All` with `/t:Clean`.  To clean a build step, add `Clean` to the start of its target name.

CI Build Status
---------------

All code is built on check-in to the `master` branch.

[![Build status](https://ci.appveyor.com/api/projects/status/dvmxa8hof2i629vo)](https://ci.appveyor.com/project/BHazel/altcoinsamples)
**AppVeyor** builds the C# implementation.

[![Build Status](https://travis-ci.org/BHazel/AltCoinSamples.svg?branch=master)](https://travis-ci.org/BHazel/AltCoinSamples)
**Travis-CI** builds the Ruby implementation.