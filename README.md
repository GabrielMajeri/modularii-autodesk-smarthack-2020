# Smart City Planner

## Configure secrets

You need to get your app credentials from [Autodesk Forge](https://forge.autodesk.com/) and then set them by running:

```sh
dotnet user-secrets set "Forge:ClientId" "<your-client-id>"
dotnet user-secrets set "Forge:ClientSecret" "<your-client-secret>"
```

## Running

To start the development server use:

```sh
dotnet run
```

To start the server, and automatically restart it when changes are made, use:

```sh
dotnet watch run
```
