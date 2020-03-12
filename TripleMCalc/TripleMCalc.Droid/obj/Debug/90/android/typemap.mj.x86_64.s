	/* Data SHA1: c8b98d0ae98cf049825a27636f23f2a4f725356c */
	.file	"typemap.mj.inc"

	/* Mapping header */
	.section	.data.mj_typemap,"aw",@progbits
	.type	mj_typemap_header, @object
	.p2align	2
	.global	mj_typemap_header
mj_typemap_header:
	/* version */
	.long	1
	/* entry-count */
	.long	6982
	/* entry-length */
	.long	268
	/* value-offset */
	.long	147
	.size	mj_typemap_header, 16

	/* Mapping data */
	.type	mj_typemap, @object
	.global	mj_typemap
mj_typemap:
	.size	mj_typemap, 1871177
	.include	"typemap.mj.inc"
