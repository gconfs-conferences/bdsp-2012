#! /usr/bin/env make
SHELL = /bin/bash

TARBALL = diapo.tgz # FIXME
SUPPORT_INPUT = \
	diapo.tex

full:
	$(MAKE) diapo.pdf && $(MAKE) diapo.pdf
diapo.pdf: $(SUPPORT_INPUT)
	pdflatex diapo.tex

clean:
	rm -f *.{aux,log,nav,out,snm,toc}
distclean: clean
	rm -f diapo.pdf
dist: distclean
	hg archive -t tgz $(TARBALL)

#END

