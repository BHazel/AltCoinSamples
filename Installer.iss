; AltCoin Samples Installation Script
; Powered by Inno Setup
; Copyright (c) Benedict W. Hazel, 2014

[Setup]
AppName=AltCoin Samples
AppVersion=1.0
DefaultDirName={pf}\B W Hazel\AltCoin Samples
DefaultGroupName=B W Hazel\AltCoin Samples

[Types]
Name: "typical"; Description: "Typical installation"
Name: "full"; Description: "Full installation"
Name: "custom"; Description: "Custom installation"; Flags: iscustom

[Components]
Name: "samples"; Description: "Sample Programs - Includes Hashing and Mining"; Types: full typical
Name: "ruby"; Description: "Ruby Scripts - Ruby versions of the sample programs (Ruby required)"; Types: full

[Files]
Source: "AltCoinSamples\Common\bin\Release\AltCoinSamples.Common.dll"; DestDir: "{app}\WPF"; Components: samples
Source: "AltCoinSamples\Mining\bin\Release\Mining.exe"; DestDir: "{app}\WPF"; Components: samples
Source: "AltCoinSamples\Mining\bin\Release\Mining.exe.config"; DestDir: "{app}\WPF"; Components: samples
Source: "AltCoinSamples\Hashing\bin\Release\Hashing.exe"; DestDir: "{app}\WPF"; Components: samples
Source: "AltCoinSamples\Hashing\bin\Release\Hashing.exe.config"; DestDir: "{app}\WPF"; Components: samples
Source: "Ruby\hashing.rb"; DestDir: "{app}\Ruby"; Components: ruby
Source: "Ruby\mining.rb"; DestDir: "{app}\Ruby"; Components: ruby