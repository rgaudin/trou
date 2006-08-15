//
// trou, a replacement tool for pbcopy
// (C) 2005 Gaudin & Evain
//

#import <AppKit/AppKit.h>
#import <algorithm>
#import <string>

void
einsatzInDasPasteboard (std::string str)
{
	NSAutoreleasePool *swimming = [NSAutoreleasePool new];
	NSPasteboard *pb = [NSPasteboard generalPasteboard];
	[pb declareTypes:[NSArray arrayWithObject:NSStringPboardType] owner:nil];
	[pb setString:[NSString stringWithUTF8String:str.c_str ()] forType:NSStringPboardType];
	[swimming release];
}

int
main (int argc, char **argv)
{
	std::string str;
	char buffer [512];
	while (size_t length = read (STDIN_FILENO, buffer, sizeof (buffer)))
		std::copy (buffer, buffer + length, std::back_inserter (str));

	einsatzInDasPasteboard (str);

	return 0;
}
