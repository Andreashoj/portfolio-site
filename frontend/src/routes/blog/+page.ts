export const prerender = true;

export function load({ data }) {
	return {
		posts: data.posts.map((post: any) => ({
			...post
		}))
	};
}
