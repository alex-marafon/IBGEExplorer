global using CreateAccount = IBGEExplorer.Account.UseCases.Create;
global using GetAccount = IBGEExplorer.Account.UseCases.Get;

global using CreateRole = IBGEExplorer.Account.UseCases.Role.Create;
global using GetRole = IBGEExplorer.Account.UseCases.Role.Get;

global using CreateUserRole = IBGEExplorer.Account.UseCases.UserRole.Create;

global using CreateCity = IBGEExplorer.Cities.UseCases.IBGE.Create;
global using ImportCity = IBGEExplorer.Cities.UseCases.IBGE.Import;
global using UpdateCity = IBGEExplorer.Cities.UseCases.Update;
global using GetCity = IBGEExplorer.Cities.UseCases.IBGE.Search;

global using GetState = IBGEExplorer.Cities.UseCases.State.Get;
global using CreateState = IBGEExplorer.Cities.UseCases.State.Create;

global using GetCounty = IBGEExplorer.Cities.UseCases.County.Get;
global using CreateCounty = IBGEExplorer.Cities.UseCases.County.Create;
