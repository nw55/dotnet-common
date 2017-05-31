#!/usr/bin/env bash

set -e

readonly THIS_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
readonly THIS_FILE="$THIS_DIR/$(basename "${BASH_SOURCE[0]}")"

artifactsDir="$THIS_DIR/artifacts"

if [ -d artifactsDir ]; then
  rm -R artifactsDir
fi

revision=${TRAVIS_JOB_ID:=1}

dotnet restore /property:BuildNumber=$revision

dotnet build -c Release /property:BuildNumber=$revision

dotnet pack -c Release -o "$artifactsDir" --no-build /property:BuildNumber=$revision
