import { formatPostDate } from '$lib/dateFormatter';
import { getSortedPostsByDate } from '$lib/dateSorting';

export const prerender = true;

export function load({ data }) {
	const formattedPostsByDate = data.posts.map((p) => formatPostDate(p));
	const sortedOrder = getSortedPostsByDate(formattedPostsByDate);
	return {
		posts: sortedOrder
	};
}
