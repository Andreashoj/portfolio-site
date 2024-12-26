export function getSortedPostsByDate(posts: SanityPost[]) {
	return posts
		.filter((post) => post.publishedAt !== null)
		.sort((a, b) => new Date(b.publishedAt).getTime() - new Date(a.publishedAt).getTime());
}
