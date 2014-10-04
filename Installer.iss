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