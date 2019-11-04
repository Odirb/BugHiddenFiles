rm secret*
touch secret1.txt
touch secret2.txt
touch secret3.txt


chflags hidden secret1.txt

setfile -a V secret2.txt

chflags hidden secret3.txt
setfile -a V secret3.txt

ls -lO secret*

getfileinfo -aV secret1.txt
getfileinfo -aV secret2.txt
getfileinfo -aV secret3.txt
