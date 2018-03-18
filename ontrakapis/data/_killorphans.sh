#!/bin/bash

docker rmi $(docker images -aq -f dangling=true)

