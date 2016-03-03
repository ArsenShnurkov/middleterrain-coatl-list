#!/bin/bash

# source execute a shell script within the context of the current shell.
# Since execution takes place within the context of the current shell,
# any changes in the shell are retained following the completion of the shell.
source ./db_code_test/runscript.sh ./db_code_test/example_of_output.sql
