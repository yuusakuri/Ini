# Yuu.Ini

This is a .NET library to parse INI.

- Parse an INI format string and convert it to an object (node).
- Convert from an node to a string.
- Add, edit, or delete nodes.
- Supports Duplicate sections.
- Supports Duplicate keys.
- Keep comments, blank lines and Order of nodes such as comments and parameters.
- Config can be changed.

## Installation

### NuGet

<https://www.nuget.org/packages/Yuu.Ini/>

## Example

### C Sharp (C#)

```c#
// Parse INI contents
var iniContents = ";ini comment";
var configuration = new Yuu.Ini.IniParserConfiguration();
var ini = Yuu.Ini.IniParser.Parse(iniContents, configuration);

// Get comment
var commentValue = ini.GetComments()[0].Value; // ";ini comment"

// Add section
ini.AddSection("section");

// Get section
var section = ini.GetSections("section")[0];

// Add comment that is new line
section.AddComment("");

// Add parameter
section.AddParameter("key","value");

// Get parameter
var parameterValue = section.GetParameters("key")[0].Value; // "value"

// Add duplicate parameters to global section
ini.GetSections("")[0].AddParameter("dup_key", "value1");
ini.GetSections("")[0].AddParameter("dup_key", "value2");

// Add duplicate sections
ini.AddSection("dup_section");
ini.AddSection("dup_section");

// Add parameters to duplicate sections
ini.GetSections("dup_section")[0].AddParameter("key1", "value1");
ini.GetSections("dup_section")[1].AddParameter("key2", "value2");

// Merge duplicate sections
ini.MergeDuplicateSections();

// Remove parameter
section.GetParameters("key")[0].Remove();

// Convert to string
var newIniContents = ini.ToString();
```

### PowerShell

```powershell
# Parse INI contents
$iniContents = ";ini comment"
$configuration = New-Object "Yuu.Ini.IniParserConfiguration"
$ini = [Yuu.Ini.IniParser]::Parse($iniContents, $configuration)

# Get comment
$commentValue = $ini.GetComments()[0].Value # ";ini comment"

# Add section
$ini.AddSection("section")

# Get section
$section = $ini.GetSections("section")[0]

# Add comment that is new line
$section.AddComment("")

# Add parameter
$section.AddParameter("key","value")

# Get parameter
$parameterValue = $section.GetParameters("key")[0].Value # "value"

# Add duplicate parameters to global section
$ini.GetSections("")[0].AddParameter("dup_key", "value1")
$ini.GetSections("")[0].AddParameter("dup_key", "value2")

# Add duplicate sections
$ini.AddSection("dup_section")
$ini.AddSection("dup_section")

# Add parameters to duplicate sections
$ini.GetSections("dup_section")[0].AddParameter("key1", "value1")
$ini.GetSections("dup_section")[1].AddParameter("key2", "value2")

# Merge duplicate sections
$ini.MergeDuplicateSections()

# Remove parameter
$section.GetParameters("key")[0].Remove()

# Convert to string
$newIniContents = $ini.ToString()
```
