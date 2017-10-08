/*
 * mkdio -- markdown front end input functions
 *
 * Copyright (C) 2007 David L Parsons.
 * The redistribution terms are provided in the COPYRIGHT file that must
 * be distributed with this source code.
 */
#include "config.h"
#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>

#include "mkdio.h"
#include "cstring.h"
#include "amalloc.h"

static int
isbaseless(const char *string, const int size)
{
	int i;
	int alphacount=0;
	for(i=0 ; i < size; ++i)
	{
		if(isalpha(string[i]))
		{
			alphacount++;
		}
		else if(string[i]==':')
		{
			// if started with colon, make it baseless.
			return alphacount == 0;
		}
		else
		{
			// not alpha, not colon
			return 1;	
		}
	}
	return 1;
}

static char *
e_basename(const char *string, const int size, void *context)
{
    char *ret;
    char *base = (char*)context;
    
    if ( base && string && isbaseless(string,size) && (ret=malloc(strlen(base)+size+2)) ) {
	strcpy(ret, base);
	strncat(ret, string, size);
	return ret;
    }
    return 0;
}

static void
e_free(char *string, void *context)
{
    if ( string ) free(string);
}

void
mkd_basename(MMIOT *document, char *base)
{
    mkd_e_url(document, e_basename);
    mkd_e_data(document, base);
    mkd_e_free(document, e_free);
}
