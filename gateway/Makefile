PATH_TO_PROJECT = .\src\Gateway
BASE_PATH = .\..

run: users reviews
	dotnet run --project $(PATH_TO_PROJECT)

users:
	dotnet fusion compose -p $(PATH_TO_PROJECT)\gateway -s $(BASE_PATH)\subgraph-1\src\Users

reviews:
	dotnet fusion compose -p $(PATH_TO_PROJECT)\gateway -s $(BASE_PATH)\subgraph-2\src\Reviews