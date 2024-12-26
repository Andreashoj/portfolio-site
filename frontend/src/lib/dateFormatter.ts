export function dateFormatter(date: string) {
	return new Date(date).toLocaleDateString('en-US', {
		year: 'numeric',
		month: 'long',
		day: 'numeric'
	});
}

export function formatPostDate(post: SanityPost): SanityPost {
	return {
		...post,
		publishedAt: dateFormatter(post.publishedAt)
	};
}
