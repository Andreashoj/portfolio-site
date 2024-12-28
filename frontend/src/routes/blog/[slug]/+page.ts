// src/routes/blog/+page.server.ts
import { formatPostDate } from '$lib/dateFormatter';

export const prerender = true;

export function load({ data }) {
	return {
		post: formatPostDate(data.post)
	};
}
