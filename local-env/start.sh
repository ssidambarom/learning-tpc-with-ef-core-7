#!/bin/sh

docker compose rm -f
docker volume prune -f
docker compose pull
docker compose up -d --build 
