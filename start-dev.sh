#!/bin/bash

# Start Postgres in Docker
docker compose -f docker-compose.dev.yml up -d

# Start frontend
cd frontend
npm run dev &

# Start backend
cd ../backend
dotnet watch run