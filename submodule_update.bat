git submodule update --remote --init --recursive --rebase
git submodule foreach "git checkout main"
pause