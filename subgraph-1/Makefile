PATH_TO_PROJECT = .\src\Users

run: generate-schema package
	dotnet run --project $(PATH_TO_PROJECT)

generate-schema:
	dotnet run --project $(PATH_TO_PROJECT) -- schema export --output schema.graphql

package:
	dotnet fusion subgraph pack -w $(PATH_TO_PROJECT)