PATH_TO_PROJECT = ./src/Gateway
BASE_PATH = ./..

run: users reviews
	dotnet run --project $(PATH_TO_PROJECT)

compose: users reviews

users:
	$(MAKE) -C $(BASE_PATH)/subgraph-1 generate-schema
	$(MAKE) -C $(BASE_PATH)/subgraph-1 package
	dotnet fusion compose -p $(PATH_TO_PROJECT)/gateway -s $(BASE_PATH)/subgraph-1/src/Users

reviews:
	$(MAKE) -C $(BASE_PATH)/subgraph-2 generate-schema
	$(MAKE) -C $(BASE_PATH)/subgraph-2 package
	dotnet fusion compose -p $(PATH_TO_PROJECT)/gateway -s $(BASE_PATH)/subgraph-2/src/Reviews