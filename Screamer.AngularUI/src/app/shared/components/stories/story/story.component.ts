import { Component } from '@angular/core';
import { map } from 'lodash';
import { StoryService } from 'src/app/core/services/story.service';

import { Zuck } from 'zuck.js';

@Component({
  selector: 'app-story',
  templateUrl: './story.component.html',
  styleUrls: ['./story.component.scss'],
})
export class StoryComponent {
  orderedStories: any[] = [];
  myStories: any;

  ngOnInit() {
    this.storyService.getStories().subscribe((res: any) => {
      this.myStories = map(res, (story: any) => {
        console.log(res);
        return {
          escort_id: story.id,
          escort: {
            user: {
              name: story.user.userName,
            },
            profile_picture: {
              url: story.user.avatars[0].url,
            },
          },
          stories: story.storyImages.map((storyImage: any) => {
            return {
              type: 'PIC',
              upload: {
                url: storyImage.url ?? '',
              },
              updated_at: '2023-06-10T10:30:00.000Z',
              text: 'First story',
            };
          }),
        };
      }).filter((story: any) => story.stories.length > 0);

      this.loadStories(this.myStories);
      this.initStories();
    });
  }

  constructor(public storyService: StoryService) {}

  getStories() {}

  loadStories(myStories: any) {
    console.log('myStories', myStories);
    /*     const stories = [
      {
        escort_id: '1',
        escort: {
          user: {
            name: 'John Doe',
          },
          profile_picture: {
            url: 'avatar1.jpg',
          },
        },
        stories: [
          {
            type: 'PIC',
            upload: {
              url: 'photo1.jpg',
            },
            updated_at: '2023-06-10T10:30:00.000Z',
            text: 'First story',
          },
        ],
      },
    ]; */

    myStories.forEach((userStory: any) => {
      const escortId = userStory.escort_id;
      const escortName = userStory.escort.user.name;
      const escortAvatar = userStory.escort.profile_picture.url;

      const userStories = userStory.stories.map((story: any) => {
        const storyType = story.type === 'PIC' ? 'photo' : 'video';
        const storyLength = storyType === 'video' ? 0 : 10;
        const storySrc = story.upload.url;
        const storyTime = new Date(story.updated_at).getTime() / 1000;
        const storyText = story.text ? story.text : '';

        return this.buildItem(
          escortId,
          storyType,
          storyLength,
          storySrc,
          storySrc,
          escortId,
          false,
          storyTime,
          storyText
        );
      });

      const existingStory = this.orderedStories.find((s) => s.id === escortId);
      if (existingStory) {
        existingStory.items.push(...userStories);
        const latestStoryTime = Math.max(
          ...userStories.map((story: any) => story.time)
        );
        if (existingStory.lastUpdated > latestStoryTime) {
          existingStory.lastUpdated = latestStoryTime;
        }
      } else {
        const newStory = {
          id: parseInt(escortId),
          photo: escortAvatar,
          link: '/profile/' + escortId,
          lastUpdated: Math.max(...userStories.map((story: any) => story.time)),
          name: escortName,
          items: userStories,
        };
        this.orderedStories.push(newStory);
      }
    });
  }

  buildItem(
    id: string,
    type: string,
    length: number,
    src: string,
    preview: string,
    link: string,
    seen: boolean,
    time: number,
    linkText: string
  ) {
    return {
      id: parseInt(id),
      type: type,
      length: length,
      src: src,
      preview: preview,
      link: '/profile/' + link,
      linkText: linkText,
      seen: seen,
      time: time,
    };
  }

  addStory() {
    const newStory = {
      escort_id: '1', // Change the escort_id to the current user's ID
      escort: {
        user: {
          name: 'John Doe', // Change the name to the current user's name
        },
        profile_picture: {
          url: 'avatar1.jpg', // Change the URL to the current user's avatar URL
        },
      },
      stories: [
        {
          type: 'PIC', // Change the type to 'PIC' for photo or 'VIDEO' for video
          upload: {
            url: 'photo2.jpg', // Change the URL to the new story's media URL
          },
          updated_at: new Date().toISOString(),
          text: 'New story', // Change the text to the new story's caption or text
        },
      ],
    };

    // Find the existing user's stories or create a new user entry
    const existingStory = this.orderedStories.find(
      (s) => s.id === newStory.escort_id
    );

    if (existingStory) {
      const storyType = newStory.stories[0].type === 'PIC' ? 'photo' : 'video';
      const storyLength = storyType === 'video' ? 0 : 10;
      const storySrc = '/' + newStory.stories[0].upload.url;
      const storyTime =
        new Date(newStory.stories[0].updated_at).getTime() / 1000;
      const storyText = newStory.stories[0].text
        ? newStory.stories[0].text
        : '';

      const newStoryItem = this.buildItem(
        newStory.escort_id,
        storyType,
        storyLength,
        storySrc,
        storySrc,
        newStory.escort_id,
        false,
        storyTime,
        storyText
      );

      existingStory.items.push(newStoryItem);
      if (existingStory.lastUpdated > storyTime) {
        existingStory.lastUpdated = storyTime;
      }
    } else {
      const escortId = newStory.escort_id;
      const escortName = newStory.escort.user.name;
      const escortAvatar = newStory.escort.profile_picture
        ? '/' + newStory.escort.profile_picture.url
        : '/img/defaultAvatar.png';

      const storyType = newStory.stories[0].type === 'PIC' ? 'photo' : 'video';
      const storyLength = storyType === 'video' ? 0 : 10;
      const storySrc = '/' + newStory.stories[0].upload.url;
      const storyTime =
        new Date(newStory.stories[0].updated_at).getTime() / 1000;
      const storyText = newStory.stories[0].text
        ? newStory.stories[0].text
        : '';

      const newStoryItem = this.buildItem(
        escortId,
        storyType,
        storyLength,
        storySrc,
        storySrc,
        escortId,
        false,
        storyTime,
        storyText
      );

      const newUserStory = {
        id: parseInt(escortId),
        photo: escortAvatar,
        link: '/profile/' + escortId,
        lastUpdated: storyTime,
        name: escortName,
        items: [newStoryItem],
      };
      this.orderedStories.push(newUserStory);
    }
  }

  initStories() {
    const stories = Zuck(document.querySelector('#stories') as any, {
      backNative: true,
      autoFullScreen: false,
      skin: 'Snapgram',
      avatars: true,
      list: false,
      cubeEffect: true,
      localStorage: true,
      stories: this.orderedStories,
    });
    document.body.style.display = 'block';
  }
}
