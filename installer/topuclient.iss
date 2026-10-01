[Setup]
AppName=TopuClient
AppVersion=1.0.0
DefaultDirName={autopf}\TopuClient
DefaultGroupName=TopuClient
OutputDir=..\output
OutputBaseFilename=TopuClient_Setup
Compression=lzma
SolidCompression=yes

[Files]
Source: "..\bin\Release\net8.0-windows\win-x64\publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{group}\TopuClient"; Filename: "{app}\TopuClient.exe"
Name: "{autodesktop}\TopuClient"; Filename: "{app}\TopuClient.exe"; Tasks: desktopicon

[Tasks]
Name: "desktopicon"; Description: "Create a &desktop icon"; GroupDescription: "Additional icons:"; Flags: unchecked
