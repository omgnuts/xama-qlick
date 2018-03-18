#!/bin/bash

docker run -it --rm -v $(pwd):/app --workdir /app microsoft/aspnetcore-build sh ./build.sh
