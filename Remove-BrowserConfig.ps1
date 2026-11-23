# Remove-BrowserConfig.ps1 - Remove all configuration files of the browser (reset to default state).

# There are situations when the application cannot be launched neither manually (via executable) nor via VS (with/without debugging).
# These problems are related with incorrect configuration files.
# This script helps to reset app's configuration and then startup the application successfully with the default configuration.

Remove-Item "setup.conf"
Remove-Item "support\configuration_profiles.json"
Remove-Item "support\preset_setup.json"
Remove-Item "locale" -Recurse -Force
Remove-Item "cache" -Recurse -Force
