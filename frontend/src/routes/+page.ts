import { formatPostDate } from '$lib/dateFormatter';
import { getSortedPostsByDate } from '$lib/dateSorting';
import { browser } from '$app/environment';
import { getUserData, token } from '$lib/stores/auth';

export const prerender = true;

export async function load({ data, url }) {
	await getUserData();
	const formattedPosts = data.posts.map((post) => formatPostDate(post));

	if (browser) {
		const urlToken = url.searchParams.get('token');
		if (urlToken) {
			token.set(urlToken);
			window.history.replaceState({}, '', url.pathname);
			await getUserData();
		} else {
			const storedToken = localStorage.getItem('token');
			if (storedToken) {
				await getUserData();
			}
		}
	}

	return {
		posts: getSortedPostsByDate(formattedPosts).slice(0, 2)
	};
}
