// src/lib/types.ts
interface SanityPost {
	title: string;
	body: any;
	publishedAt: string;
	slug: Slug;
	pageView?: number;
	description?: string;
	categories: Category[];
	likes: number;
}

interface Slug {
	current: string;
	_type: string;
}

interface PageData {
	post: SanityPost;
}

interface Blog {
	id: string;
	slug: string;
	pageView: number;
	likes: number;
}

interface Category {
	title: string;
	description: string;
}
