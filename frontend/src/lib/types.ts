// src/lib/types.ts
interface SanityPost {
	title: string;
	author: string;
	body: any;
	publishedAt: string;
	slug: Slug;
	pageView?: number;
	description?: string;
	categories: Category[];
}

interface Slug {
	current: string;
	_type: string;
}

interface PageData {
	post: SanityPost;
}

interface PageView {
	id: string;
	slug: string;
	pageView: number;
}

interface Category {
	title: string;
	description: string;
}
