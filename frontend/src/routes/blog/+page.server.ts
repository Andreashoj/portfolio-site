// src/routes/blog/+page.server.ts
import { client } from '$lib/sanity';

export const prerender = true;

export async function load() {
	const posts: SanityPost[] = await client.fetch(`
        *[_type == "post"] {
            title,
            slug,
            body,
            publishedAt,
            description,
            "author": author->name,
            "categories": categories[]->{ 
                title,
                description
            }
        }
    `);
	return { posts };
}
