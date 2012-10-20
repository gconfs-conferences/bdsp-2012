#! /usr/bin/env make

SHELL = /bin/bash

full: conf-BDSP-tp conf-BDSP-conf

conf-BDSP-tp:
	@(cd ./tp/TP\ Invaders && $(MAKE))
	@(cd ./tp/TP\ SVN && $(MAKE))

conf-BDSP-conf:
	@(cd ./conf && $(MAKE))

clean:
	@(cd ./tp/TP\ Invaders && $(MAKE) $@)
	@(cd ./tp/TP\ SVN && $(MAKE) $@)
	@(cd ./conf && $(MAKE) $@)

#END
