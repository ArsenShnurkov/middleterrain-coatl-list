#!/bin/bash

DATABASE=mc_list
USERNAME=mc_test
psql --username=postgres --dbname="postgresql://localhost:5432/" --command="DROP DATABASE IF EXISTS ${DATABASE};" || exit
psql --username=postgres --dbname="postgresql://localhost:5432/" --command="CREATE DATABASE ${DATABASE};" || exit
psql --username=postgres --dbname="postgresql://localhost:5432/" --command="DROP USER IF EXISTS ${USERNAME};" || exit
psql --username=postgres --dbname="postgresql://localhost:5432/" --command="CREATE USER ${USERNAME};" || exit
psql --username=postgres --dbname="postgresql://localhost:5432/" --command="GRANT ALL privileges ON DATABASE ${DATABASE} TO ${USERNAME};" || exit
psql --username=${USERNAME} --dbname="postgresql://localhost:5432/${DATABASE}" --file=$1 || exit
echo "script execution completed successfully"