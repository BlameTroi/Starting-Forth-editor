\ deblocker.fs -- Convert a block to text -- T.Brumley

use blocks.fb                   \ the default

0 value current-block           \ shouldn't change often

1024 constant block-size        \ minimize magic numbers
64 constant line-length

\ This correctly lists any screen proving that I understand how
\ to deal with them.
: do-a-screen ( n -- )             \ screen number
   n to current-block              \ save
   current-block block             \ load and get address
   0                               \ line counter
   block-size 1- 0 do              \ let's loop over the lines
      cr 1+ dup 3 .r space         \ next line
      over i +                     \ first byte of line
      line-length -trailing type   \ deblank and print
      36 emit                      \ visually indicate eol
   line-length +loop               \ and next line
   2drop ;