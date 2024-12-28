// src/lib/sanityRenderer.ts
// src/lib/sanityRenderer.ts
import { toHTML } from '@portabletext/to-html';
import Prism from 'prismjs';
import 'prismjs/components/prism-typescript';

export function renderContent(blocks: any) {
	const html = toHTML(blocks, {
		components: {
			types: {
				code: ({ value }) => {
					const highlighted = Prism.highlight(value.code, Prism.languages.typescript, 'typescript');

					// Add data-line attribute for highlighting
					const highlightAttr = value.highlightedLines
						? `data-line="${value.highlightedLines.join(',')}"`
						: '';

					return `
                        <div class="code-window mb-6">
                            <div class="code-header">
                                <div class="window-buttons">
                                    <span class="close"></span>
                                    <span class="minimize"></span>
                                    <span class="maximize"></span>
                                </div>
                                <div class="tab">
                                    <span class="filename">${value.filename}</span>
                                </div>
                                <span class="language">${value.language}</span>
                            </div>
                            <pre class="line-numbers" ${highlightAttr}><code class="language-typescript">${highlighted}</code></pre>
                        </div>
                    `;
				}
			},
			block: {
				// Define handling for headings
				h1: ({ children }) => `<h1 class="text-3xl mb-2">${children}</h1>`,
				h2: ({ children }) => `<h2 class="text-2xl mb-2">${children}</h2>`,
				h3: ({ children }) => `<h3 class="text-xl mb-2">${children}</h3>`,
				normal: ({ children }) => `<p class="mb-2">${children}</p>` // Default paragraph
			},
			marks: {
				// Handle inline marks (e.g., links, bold text)
				strong: ({ children }) => `<strong>${children}</strong>`,
				em: ({ children }) => `<em>${children}</em>`,
				link: ({ children, value }) =>
					`<a href="${value.href}" target="${value.newTab ? '_blank' : '_self'}">${children}</a>`
			}
		}
	});
	return html;
}
