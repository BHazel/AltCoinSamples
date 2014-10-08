; AltCoin Samples Installation Script
; Powered by Inno Setup
; Copyright (c) Benedict W. Hazel, 2014

[Setup]
AppName=AltCoin Samples
AppPublisher=B W Hazel
AppPublisherURL=http://bwhazel.uk
AppVersion=1.0
AppCopyright=Copyright (c) Benedict W. Hazel, 2014
UninstallDisplayName=AltCoin Samples
DefaultDirName={pf}\B W Hazel\AltCoin Samples
DefaultGroupName=B W Hazel\AltCoin Samples
OutputDir=Installer

[Types]
Name: "typical"; Description: "Typical installation"
Name: "full"; Description: "Full installation"
Name: "custom"; Description: "Custom installation"; Flags: iscustom

[Components]
Name: "samples"; Description: "Sample Programs - Includes Hashing and Mining"; Types: full typical
Name: "ruby"; Description: "Ruby Scripts - Ruby versions of the sample programs (Ruby required)"; Types: full

[Files]
Source: "AltCoinSamples\Common\bin\Release\AltCoinSamples.Common.dll"; DestDir: "{app}\WPF"; Components: samples
Source: "AltCoinSamples\Hashing\bin\Release\Hashing.exe"; DestDir: "{app}\WPF"; Components: samples
Source: "AltCoinSamples\Hashing\bin\Release\Hashing.exe.config"; DestDir: "{app}\WPF"; Components: samples
Source: "AltCoinSamples\Mining\bin\Release\Mining.exe"; DestDir: "{app}\WPF"; Components: samples
Source: "AltCoinSamples\Mining\bin\Release\Mining.exe.config"; DestDir: "{app}\WPF"; Components: samples
Source: "AltCoinSamples\Documentation\hashing.html"; DestDir: "{app}\WPF"; Components: samples
Source: "AltCoinSamples\Documentation\hashing.png"; DestDir: "{app}\WPF"; Components: samples
Source: "AltCoinSamples\Documentation\hashingresult.png"; DestDir: "{app}\WPF"; Components: samples
Source: "AltCoinSamples\Documentation\mining.html"; DestDir: "{app}\WPF"; Components: samples
Source: "AltCoinSamples\Documentation\miningresult.png"; DestDir: "{app}\WPF"; Components: samples
Source: "Ruby\hashing.rb"; DestDir: "{app}\Ruby"; Components: ruby
Source: "Ruby\mining.rb"; DestDir: "{app}\Ruby"; Components: ruby
Source: "Ruby\hashing.html"; DestDir: "{app}\Ruby"; Components: ruby
Source: "Ruby\mining.html"; DestDir: "{app}\Ruby"; Components: ruby

[Icons]
Name: "{group}\Hashing"; Filename: "{app}\WPF\Hashing.exe"
Name: "{group}\Hashing Instructions"; Filename: "{app}\WPF\hashing.html"
Name: "{group}\Hashing Instructions (Ruby)"; Filename: "{app}\Ruby\hashing.html"; Flags: createonlyiffileexists
Name: "{group}\Mining"; Filename: "{app}\WPF\Mining.exe"
Name: "{group}\Mining Instructions"; Filename: "{app}\WPF\mining.html"
Name: "{group}\Mining Instructions (Ruby)"; Filename: "{app}\Ruby\mining.html"; Flags: createonlyiffileexists
Name: "{group}\Uninstall AltCoin Samples"; Filename: "{uninstallexe}"