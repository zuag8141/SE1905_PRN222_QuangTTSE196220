# .NET 8 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that a .NET 8.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 8.0 upgrade.
3. Upgrade `zSubscription.Entities.QuangTT.csproj`.
4. Upgrade `zSubscription.Services.QuangTT.csproj`.
5. Upgrade `zSubscription.Repositories.QuangTT.csproj`.
6. Upgrade `zSubscription.MVCWebApp.QuangTT.csproj`.

## Settings

### Excluded projects

None.

### Project upgrade details

#### `zSubscription.Entities.QuangTT.csproj` modifications

Project properties changes:
  - Target framework should be changed from `net9.0` to `net8.0`.

Other changes:
  - Verify the project continues to build against .NET 8 with its existing Entity Framework Core package reference.

#### `zSubscription.Services.QuangTT.csproj` modifications

Project properties changes:
  - Target framework should be changed from `net9.0` to `net8.0`.

Other changes:
  - Verify the project reference to `zSubscription.Repositories.QuangTT.csproj` remains valid after the downgrade.

#### `zSubscription.Repositories.QuangTT.csproj` modifications

Project properties changes:
  - Target framework should be changed from `net9.0` to `net8.0`.

Other changes:
  - Verify compatibility of the existing `Microsoft.EntityFrameworkCore`, `Microsoft.Extensions.Configuration`, and `Microsoft.Extensions.Configuration.Json` package references with .NET 8.

#### `zSubscription.MVCWebApp.QuangTT.csproj` modifications

Project properties changes:
  - No target framework change required; the project already targets `net8.0`.

Other changes:
  - Validate the project still builds cleanly after dependent projects are downgraded to .NET 8.
