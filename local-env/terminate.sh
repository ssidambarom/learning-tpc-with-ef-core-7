#!/bin/sh

docker compose rm -s -f -v
docker volume prune -f
