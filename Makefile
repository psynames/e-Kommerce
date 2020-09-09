PROJECT_NAME ?= skinet
ORG_NAME ?= skinet
REPO_NAME ?= skinet
.PHONEY: migrations db

migrations:
	cd ./INFRASTRUCTURE && dotnet ef --startup-project ../API/ migrations add $(mname) && cd ..

db:
	cd ./INFRASTRUCTURE && dotnet ef --startup-project ../API/ database update  && cd ..
