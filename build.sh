#!/usr/bin/env bash

set -e

readonly THIS_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
readonly THIS_FILE="$THIS_DIR/$(basename "${BASH_SOURCE[0]}")"

artifactsDir="$THIS_DIR/artifacts"

if [ -d artifactsDir ]; then
  rm -R artifactsDir
fi

dotnet restore

dotnet build

revision=${TRAVIS_JOB_ID:=1}
revision=$(printf "%04d" $revision)

dotnet pack -c Release -o "$artifactsDir" --version-suffix $revision
