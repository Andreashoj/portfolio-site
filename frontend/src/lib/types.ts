// src/lib/types.ts
interface SanityPost {
	title: string;
	author: string;
	body: any;
	publishedAt: string;
	slug: Slug;
	pageView?: number;
}

interface Slug {
	current: string;
	_type: string;
}

// For your page data
interface PageData {
	post: SanityPost;
}

interface PageView {
	id: string;
	slug: string;
	pageView: number;
}
