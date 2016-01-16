# Thinq = Linq + Mathmatics

![Screenshot](https://github.com/AdamRakaska/Thinq/blob/master/Thinq.PNG)


Currently supports:
  - Finding the intersection of any number of arithmetic progression sequences, including infinite sets.
  - Ranges over the domain of whole numbers.
  
  

The first attempt at the intersection of sequences used IEnumerables, but because enumerables hold on to every value theyve ever received, the application could easily make the computer run out of memory.

Round two changed the underlying loop driving the IEnumerable to yield return only values that were a multiples of the common diffrence between the underlying arithmetic sequences. In other words, each call to GetNext is the next whole number that appears in all of the arithmetic sequences, or the intersection.

How much of a performance benifit did we gain? Using the first 8 prime numbers, finding common multiples from zero to 10 million took half a second. Same 8 primes to 50 million would throw an OutOfMemoryException. In comparison, now it can find multiples of the same 8 primes up to one billion in 25 seconds! Now the problem is CPU constrained once more, instead of memory.



Wishlist:
  - Compose Range's together.
  - Make a system of linear equations solver composing ranges.
  - Coffee
  - Maths



