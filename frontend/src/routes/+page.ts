export const prerender = true;

export function load({ data }) {
	console.log(data.posts[0].slug);
	return {
		posts: getLatestPosts(
			data.posts.map(
				(post) =>
					({
						...post,
						publishedAt: post.publishedAt
							? new Date(post.publishedAt).toLocaleDateString('en-US', {
									year: 'numeric',
									month: 'long',
									day: 'numeric'
								})
							: null
					}) as SanityPost
			)
		)
	};
}

const getLatestPosts = (posts: SanityPost[]) => {
	return posts
		.filter((post) => post.publishedAt !== null)
		.sort((a, b) => new Date(b.publishedAt).getTime() - new Date(a.publishedAt).getTime())
		.slice(0, 2);
};
