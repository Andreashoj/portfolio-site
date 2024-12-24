// src/routes/blog/[slug]/+page.server.ts
import { client } from '$lib/sanity';
import { error } from '@sveltejs/kit';

export async function entries() {
	const slugs = await client.fetch(`
        *[_type == "post"].slug.current
    `);
	return slugs.map((slug: string) => ({ slug }));
}

export const prerender = true;

export async function load({ params }) {
	const post = await client.fetch<SanityPost>(
		`
        *[_type == "post" && slug.current == $slug][0] {
            title,
            body,
            publishedAt,
            slug,
            "author": author->name
        }
    `,
		{ slug: params.slug }
	);

	if (!post) {
		throw error(404, 'Post not found');
	}

	return { post: post };
}
