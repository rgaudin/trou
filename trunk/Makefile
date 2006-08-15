CC	= g++ -Os -Wall -framework AppKit
UCC	= $(CC) -isysroot /Developer/SDKs/MacOSX10.4u.sdk

all:
	$(CC) -o trou trou.mm
universal:
	$(UCC) -arch i386 -o trou-i386 trou.mm
	$(UCC) -arch ppc -o trou-ppc trou.mm
	lipo -create -output trou trou-ppc trou-i386
	rm trou-ppc
	rm trou-i386
install:
	cp trou /usr/bin/
clean:
	rm trou
