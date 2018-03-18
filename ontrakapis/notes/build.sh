#!/bin/bash

set -e
dotnet restore
#dotnet test test/WebTests/project.json

rm -rf $(pwd)/publish
dotnet publish -c release -o ./publish/web
mv $(pwd)/src/api/publish $(pwd)/

cp configs/Dockerfile $(pwd)/publish/web
cp configs/docker_run.sh $(pwd)/publish/web


# clean up
rm -rf $(pwd)/src/api/bin
rm -rf $(pwd)/src/api/obj

#docker run -it -v $(PWD):/app --workdir /app microsoft/aspnetcore-build bash -c dotnet restore && dotnet publish -c Release -o ./bin/Release/PublishOutput
