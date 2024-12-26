import { formatPostDate } from '$lib/dateFormatter';
import { getSortedPostsByDate } from '$lib/dateSorting';

export const prerender = true;

export function load({ data }) {
	const formattedPosts = data.posts.map((post) => formatPostDate(post));
	return {
		posts: getSortedPostsByDate(formattedPosts).slice(0, 2)
	};
}
